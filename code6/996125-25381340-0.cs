    public string RandomGenerator()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var numbers= "0123456789";
            var random = new Random();
            var letterResult = new string(Enumerable.Repeat(chars, 3).Select(s => s[random.Next(s.Length)]).ToArray());    
            var numberResult = new string(Enumerable.Repeat(number, 6).Select(s => s[random.Next(s.Length)]).ToArray());
    
            txtReference.Text = letterResult + numberResults;
    
            return result;
    
        }
