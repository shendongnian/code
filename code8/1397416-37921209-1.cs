    private void UpdateData(){
        Task.Factory.StartNew(()=>{
            connection.Open();
            DataProperty = yourNewData;
            connection.Close();
        });
    }
