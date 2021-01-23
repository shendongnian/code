     public string RandomGenerator()
            {     
                    var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            		var numbers = "0123456789";
                    var random = new Random();
                    var letters = new string(
                                    Enumerable.Repeat(chars, 3)
                                    .Select(s => s[random.Next(s.Length)])
                                    .ToArray());
                  
            		
            		var numbers = new string(
                                    Enumerable.Repeat(numbers, 6)
                                    .Select(s => s[random.Next(s.Length)])
                                    .ToArray());
                    var result = letters + numbers;
                    txtReference.Text = result;
                    return result;
        }
