    ((student, courses) =>
                    {
                        var ctrId = 0;  
                        courses.ToList().ForEach(cour =>
                        {
                            if (cour != null)
                            {
                                enrollLst[ctrId].Course = cour;
                                ctrId++;
                            }
                            else
                            {
                                enrollLst[ctrId].Course = null;
                                ctrId++;
                            }   
                        });
                        student.Enrollments = enrollLst;
                    })).FirstOrDefault(); 
