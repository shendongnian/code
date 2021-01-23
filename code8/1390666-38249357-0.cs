    Dictionary<string, string> MotorPNDict = new Dictionary<string, string>();
            int csvindex = 0;
            int HeaderRows = 1;
            foreach (var row in csv.Skip(HeaderRows))
            {
               if (csvindex < 10)
               {
                  /* Here we get the Bay/Port mapping and store them in ascending order regardless of the CSV order, i.e. bay 1 will always be array position 0*/
                  var index = Convert.ToInt32(row[0]) - 1;
                  BayPortMap[index][0] = Convert.ToInt32(row[0]);
                  BayPortMap[index][1] = Convert.ToInt32(row[1]);
                  BayPortMap[index][2] = -1;
               }
               else
               {
                  switch (csvindex)
                  {
                     case 10:
                        {
                           TesterNumber = row[1];
                           break;
                        }
                     case 11:
                        {
                           ReportLocation = row[1];
                           break;
                        }
                     case 12:
                        {
                           DBSource = row[1];
                           break;
                        }
                     case 13:
                        {
                           InitialCatalog = row[1];
                           break;
                        }
                     default:
                        {
                           /* add Motor PNs and there corresponding types to a dictionary */
                           MotorPNDict.Add(row[1], row[0]);
                           break;
                        }
                  }
               }
               csvindex++;
            }
