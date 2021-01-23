            string strReturn = string.Empty;           
            var formattedDate = DateTime.ParseExact(inputDate, inputDateFormat, System.Globalization.CultureInfo.InvariantCulture);
            strReturn = formattedDate.ToString(destinationDateFormat);              
            return strReturn;
        }
