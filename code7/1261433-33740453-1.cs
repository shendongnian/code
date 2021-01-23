      //Open the two xml files examples
      FileStream file1 = new FileStream(@"c:\New_Result_Tournaments.xml", FileMode.Open);
      FileStream file2 = new FileStream(@"c:\Sports_odds_databas.xml", FileMode.Open);
      // 
      XmlSerializer ser = new XmlSerializer(typeof(yourNamespace.yourClass));
      try
      {
        myNamespace.yourClass NewResult = ser.Deserialize(file1) as myNamespace.yourClass;
        yourNamespace.yourClass SportOddsDatbas = ser.Deserialize(file2) as myNamespace.yourClass;
        if( NewResult != null && SportOddsDatbas != null)
        {
          /* Here you should have access both xml files just 
             add information want update seconed file with from 
             the first.*/
          // Save the updates made in c:\Sports_odds_databas.xml
          serializer.Serialize(file2, SportOddsDatbas);
        }
      }
      catch (Exception ex)
      {
        // Todo)
        // Very good to use the exception to find fault mapping of XML can save lot of time.
      }
      file1.Close();
      file2.Close();
