    SQLiteAsyncConnection connection1 = new SQLiteAsyncConnection("Employee.sqlite");
    SQLiteAsyncConnection connection2 = new SQLiteAsyncConnection("Customer.sqlite"); 
    public async void MergeDatabase()
        {
            string test1 = ApplicationData.Current.LocalFolder.Path + "\\Employee.sqlite";
            string test2 = ApplicationData.Current.LocalFolder.Path + "\\Customer.sqlite";
            await connection1.ExecuteAsync("ATTACH DATABASE '" + test1 + "' AS db1;");
            await connection1.ExecuteAsync("ATTACH DATABASE '" + test2 + "' AS db2;");
            string query = "INSERT INTO db2.TableEmployee ("
                  + "Name, Address) "
                  + "SELECT Name, Address "
                  + "FROM db1.TableEmployee";
            await connection1.ExecuteAsync(query);
        }
