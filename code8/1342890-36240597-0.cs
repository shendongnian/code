    public void sayHappyBirthDay(Dictionary<string, DateTime> nameBirthDay)
    {
        DateTime today = DateTime.Now;
        foreach (var n in nameBirthDay)
        {
            if (today.Month == n.Value.Month && today.Day == n.Value.Day)
            {
                string bday = n.Key;
                MessageBox.Show(string.Format("Hello, today is {0}. name of person: {1}", today, bday), "Hello", MessageBoxButtons.OK);
            }
        }
    }
