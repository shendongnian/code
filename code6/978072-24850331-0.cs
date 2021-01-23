            XmlSerializer serializer = new XmlSerializer(typeof(currents));
            currents stronglyTypedResult = serializer.Deserialize(new StringReader(xmlString)) as currents;
            foreach (var item in stronglyTypedResult.current)
            {
                Console.WriteLine(item.countryCode);
            }
          
