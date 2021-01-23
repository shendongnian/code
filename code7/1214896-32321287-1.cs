    var db = new DataClasses1DataContext();
        var history =( from a in db.ResultsHistories
            where
                a.PlayerOne == _playerOne && a.PlayerTwo == comboBox.Text ||
                a.PlayerTwo == _playerOne && a.PlayerOne == comboBox.Text
            select new
            {
                PlayerOne = a.PlayerOne,
                PlayerTwo = a.PlayerTwo,
                Date = a.Date,
                ResultOne = a.ResultOne,
                ResultTwo = a.ResultTwo
            }).ToList();
        listBox.ItemsSource = history;
