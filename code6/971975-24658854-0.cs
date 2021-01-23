            string s = "{'rate':50,'information':{'height':70,'ssn':43,'name':'andrew'}}".Replace('\'', '\"');
            var obj = JsonConvert.DeserializeObject(s);
            dynamic jsonArray = obj;
            foreach (var item in jsonArray)
            {
                Console.WriteLine(item.rate);
                Console.WriteLine(item.ssn);
            }
        }
