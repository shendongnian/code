    async void btnSave_Click(object sender, EventArgs e)
    {
        // get string result of the operation
        var result = await Task.Run(() => SaveTheData());
        if (result != "OK")
        {
            msgBox = new CustomMessageBox(
                        "Файл добавлен в базу, строки " + result +
                        " не были добавлены по причине неверных входных данных",
                        "Уведомление");
            msgBox.Show();
        }
    }
