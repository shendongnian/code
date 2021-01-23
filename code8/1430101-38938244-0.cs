    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using System.Data.OleDb;
    using System.IO;
    using Encog.Neural.Networks;
    using Encog.Neural.Networks.Layers;
    using Encog.Engine.Network.Activation;
    using Encog.ML.Data;
    using Encog.Neural.Networks.Training.Propagation.Resilient;
    using Encog.ML.Train;
    using Encog.ML.Data.Basic;
    using Encog;
    using System.Data;
    using System.Data.OleDb;
    using System.IO;
    namespace encog_sample_csharp
    {
        internal class Program
        {
            /// <summary>
            /// Input for the XOR function.
            /// </summary>
            const string FILENAME = @"c:\temp\BidTraining.csv";
            static DataTable dt = null;
            private static void Main(string[] args)
            {
                CSVReader reader = new CSVReader();
                DataSet ds = reader.ReadCSVFile(FILENAME, true);
                dt = ds.Tables["Table1"];
     
                // create a neural network, without using a factory
                var network = new BasicNetwork();
                network.AddLayer(new BasicLayer(null, true, 17));
                network.AddLayer(new BasicLayer(new ActivationSigmoid(), false, 2));
                network.Structure.FinalizeStructure();
                network.Reset();
                Dictionarys dict = new Dictionarys();
                // create training dat
                IMLDataSet dataSet = dict.GetDataSet(dt);
                // train the neural network
                IMLTrain train = new ResilientPropagation(network, dataSet);
                int epoch = 1;
                do
                {
                    train.Iteration();
                    Console.WriteLine(@"Epoch #" + epoch + @" Error:" + train.Error);
                    epoch++;
                } while (train.Error > 0.01);
                train.FinishTraining();
                // test the neural network
                Console.WriteLine(@"Neural Network Results:");
                foreach (IMLDataPair pair in dataSet)
                {
                    IMLData output = network.Compute(pair.Input);
                    Console.WriteLine(pair.Input[0] + @"," + pair.Input[1]
                                      + @", actual=" + output[0] + @",ideal=" + pair.Ideal[0]);
                }
                EncogFramework.Instance.Shutdown();
            }
        }
        public class Dictionarys
        {
            public double[][] inputNeurons;
            public double[][] outputNeurons;
            public static Dictionary<string, double> bid = new Dictionary<string, double>(){
                 {"None", -1.0},
                 {"Pass", 0.0},
                 {"One", 1.0},
                 {"Two", 2.0},
                 {"Three", 3.0},
                 {"Four", 4.0},
                 {"Five", 5.0},
                 {"Six", 6.0}
            };
            public static Dictionary<string, double> rank = new Dictionary<string, double>() {
                {"Ace", 1.0},
                {"Two", 2.0},
                {"Three", 3.0},
                {"Four", 4.0},
                {"Five", 5.0},
                {"Six", 6.0},
                {"Seven", 7.0},
                {"Eight", 8.0},
                {"Nine", 9.0},
                {"Ten", 10.0},
                {"Jack", 11.0},
                {"Queen", 12.0},
                {"King", 13.0}
            };
            public static Dictionary<string, double> suit = new Dictionary<string, double>() {
                {"None",-1.0},
                {"SuitA",1.0},
                {"SuitB",2.0},
                {"SuitC",3.0},
                {"SuitD",4.0}
            };
            public IMLDataSet GetDataSet(DataTable dt)
            {
                inputNeurons = dt.AsEnumerable().Select(x => new[] {
                    (double)x.Field<int>(0),
                    (double)x.Field<int>(1),
                    bid[x.Field<string>(2)],
                    bid[x.Field<string>(3)],
                    bid[x.Field<string>(4)],
                    rank[x.Field<string>(5)],
                    suit[x.Field<string>(6)],
                    rank[x.Field<string>(7)],
                    suit[x.Field<string>(8)],
                    rank[x.Field<string>(9)],
                    suit[x.Field<string>(10)],
                    rank[x.Field<string>(11)],
                    suit[x.Field<string>(12)],
                    rank[x.Field<string>(13)],
                    suit[x.Field<string>(14)],
                    rank[x.Field<string>(15)],
                    suit[x.Field<string>(16)]
                }).ToArray();
                outputNeurons = dt.AsEnumerable().Select(x => new[] {
                    bid[x.Field<string>(17)],
                    suit[x.Field<string>(18)]
                }).ToArray();
                IMLDataSet trainingSet = new BasicMLDataSet(inputNeurons, outputNeurons);    
                return trainingSet;
            }
        }
        public class CSVReader
        {
            public DataSet ReadCSVFile(string fullPath, bool headerRow)
            {
                string path = fullPath.Substring(0, fullPath.LastIndexOf("\\") + 1);
                string filename = fullPath.Substring(fullPath.LastIndexOf("\\") + 1);
                DataSet ds = new DataSet();
                try
                {
                    if (File.Exists(fullPath))
                    {
                        string ConStr = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0}" + ";Extended Properties=\"Text;HDR={1};FMT=Delimited\\\"", path, headerRow ? "Yes" : "No");
                        string SQL = string.Format("SELECT * FROM {0}", filename);
                        OleDbDataAdapter adapter = new OleDbDataAdapter(SQL, ConStr);
                        adapter.Fill(ds, "TextFile");
                        ds.Tables[0].TableName = "Table1";
                    }
                    foreach (DataColumn col in ds.Tables["Table1"].Columns)
                    {
                        col.ColumnName = col.ColumnName.Replace(" ", "_");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return ds;
            }
        }
    }
