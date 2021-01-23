    public static async void CreateDbAsync() 
            { 
                App.Connection = new SQLiteAsyncConnection("UniversityDB.db"); 
     
                var universityTask = App.Connection.CreateTableAsync<University>(); 
                var studentTask = App.Connection.CreateTableAsync<Student>(); 
     
                await Task.WhenAll(new Task[] { universityTask, studentTask }); 
            }
