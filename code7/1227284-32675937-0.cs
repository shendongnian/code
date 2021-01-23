            string parameters = @"Splash\0\0Message here.\01Back\0\0";
            var paramList = new List<string>(parameters.Split(new string[] { @"\0" }, StringSplitOptions.None).Take(5));
            for(int i = 0; i < paramList.Count; i++)
            {
                Console.WriteLine(i.ToString() + ": " + paramList[i]);
            }
