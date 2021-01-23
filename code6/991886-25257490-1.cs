    var nodeInfo_List = new List<string[]>();
            var nodeID_List = new List<double[]>();
            var nodeX_List = new List<double[]>();
            var nodeY_List = new List<double[]>();
            var nodeZ_List = new List<double[]>();
            StreamReader myfile = new StreamReader(@"D:\Documents\PIP_Task\PB_devTask\PB_devTask\ADMIN PHASE 2-a3.std");
           
          
      string line;
            do
            {
                line = myfile.ReadLine();
            } while (!line.Equals("JOINT COORDINATES"));
           
                do
                {
                    var nums = myfile.ReadLine();
                    if (!String.IsNullOrWhiteSpace(nums))
                    {
                        nodeInfo_List.Add(nums.Split(';'));
                        foreach (var node in nodeInfo_List)
                        {
                            Console.WriteLine("{0}: ", node);
                        }
                    }
                } while (!myfile.EndOfStream);         
