            foreach (var headerItem in response.Headers)
            {
                IEnumerable<string> values;
                string HeaderItemValue="";
                values = response.Headers.GetValues(headerItem.ToString());
                foreach (var valueItem in values)
                {
                    HeaderItemValue = HeaderItemValue + valueItem + ";";                    
                }
                Console.WriteLine(headerItem + " : " + HeaderItemValue);
            }
