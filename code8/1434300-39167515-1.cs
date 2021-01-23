	    using System;
		using System.Collections.Generic;
		using System.Linq;
		using System.Text;
		using System.Threading.Tasks;
		using Encog.MathUtil.RBF;
		using Encog.Neural.Data.Basic;
		using Encog.Neural.NeuralData;
		using Encog.Neural.Rbf.Training;
		using Encog.Neural.RBF;
		namespace TestRBF
		{
			class Program
			{
				public static double[][] XORInput = {
				new[] {0.0, 0.0},
				new[] {1.0, 0.0},
				new[] {0.0, 1.0},
				new[] {1.0, 1.0}
			};
				public static double[][] XORIdeal = {
				new[] {0.0},
				new[] {1.0},
				new[] {1.0},
				new[] {0.0}
			};
				static void Main(string[] args)
				{
					int dimension = 2; // XORInput provides two-dimensional inputs. Not 8. 
					/*
					If XORInput is  8 dimensional  it should be like this:
					
					public static double[][] XORInput = {
					new[] {0.0, 0.0,0.0, 0.0,0.0, 0.0,0.0, 0.0}, 
					.
					.	
					.*/
					int numNeuronsPerDimension = 4; // could be also 16, 64, 256. I suppose it should accept 8, 32 but it needs additional investigation
					double volumeNeuronWidth = 2.0 / numNeuronsPerDimension;
					bool includeEdgeRBFs = true;
					RBFNetwork n = new RBFNetwork(dimension, numNeuronsPerDimension, 1, RBFEnum.Gaussian);
					n.SetRBFCentersAndWidthsEqualSpacing(0, 1, RBFEnum.Gaussian, volumeNeuronWidth, includeEdgeRBFs);
					//n.RandomizeRBFCentersAndWidths(0, 1, RBFEnum.Gaussian);
					INeuralDataSet trainingSet = new BasicNeuralDataSet(XORInput, XORIdeal);
					SVDTraining train = new SVDTraining(n, trainingSet);
					int epoch = 1;
					do
					{
						train.Iteration();
						Console.WriteLine("Epoch #" + epoch + " Error:" + train.Error);
						epoch++;
					} while ((epoch < 1) && (train.Error > 0.001));
				}
			}
		}
