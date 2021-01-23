      var data = new List<MyDataObject>();
                var SampleData = GetMeSampleData;
                var count = SampleData.Count();
                for (int i=0;i<count;i++)
                {
                    var rootAdded = false;
                    var relationId = SampleData[i].relationId;
                    var alreadyExist = data.Any(x => x.Id == SampleData[i].Id);
                    var mydataObject = new MyDataObject();
                    if (!alreadyExist && SampleData[i].RelationId != 0)
                    {
                        mydataObject = SampleData[i];
                        rootAdded = true;
                    }
                    for(int j=i+1;j<count;j++)
                    {
                        if ((SampleData[j].RelationId == 0 && rootAdded))
                        {
                            mydataObject.Children.Add(SampleData[j]);
                        }
                        if (SampleData[j].SubjectId != 0) 
                            break;
                        
                    }
                    
                    if (rootAdded)
                    {
                        data.Add(mydataObject);
                    }
