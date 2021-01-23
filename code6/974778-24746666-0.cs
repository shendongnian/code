        CultureInfo local_culture = new CultureInfo("en-GB");
		DateTimeStyles styles;
		styles = DateTimeStyles.None;
        String result = "2014/05/01";
        try
        {
            DateTime dt = DateTime.MinValue;
            if (DateTime.TryParse(result, local_culture, styles, out dt))
            {
                Console.WriteLine(dt);
            }
        }
		catch (Exception e)
        {
        }
