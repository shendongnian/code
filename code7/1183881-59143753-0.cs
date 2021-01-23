//This is from the MailBnfHelper class of the System.Net.Mime namespace.
internal static bool HasCROrLF(string data)
    {
      for (int index = 0; index < data.Length; ++index)
      {
        if (data[index] == '\r' || data[index] == '\n')
          return true;
      }
      return false;
    }
