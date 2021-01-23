    _connection.BeginTransaction();
                        var listPeople = new List<Table_People>();
                        foreach (var item in peopleList.People)
                        {
                            var peopleTable = new Table_People();
                            peopleTable.AccountNumber = item.AccountNumber;
                            peopleTable.FirstName = item.FirstName;
                            peopleTable.LastName = item.LastName;
                            peopleTable.MiddleName = item.MiddleName;
                            peopleTable.PersonID = item.ID;
                            listPeople.Add(peopleTable);
                            //_peopleManager.SaveTask(peopleTable);
                        }
                        _connection.InsertAll(listPeople);
                        _connection.Commit();
