                //method 2 doing inline
                TaskFactory<IEnumerable<TMLiveData.JobType>> tf = new TaskFactory<IEnumerable<TMLiveData.JobType>>();
                IEnumerable < TMLiveData.JobType > jobTypes = await tf.FromAsync(query.BeginExecute(null, null),
                                           iar => query.EndExecute(iar));
                foreach (TMLiveData.JobType jobType in jobTypes )
                {
                    mResult += jobType.JobType1 + ",";
                }
                //method 1 using the onQueryComplete delegate function
                //query.BeginExecute(OnQueryComplete, query);
            }
