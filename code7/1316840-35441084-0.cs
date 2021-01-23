    using StreamWriter sw = new StreamWriter(ViewerPointsFile)
        {
           spoints = sb.ToString();
           sw.Write(spoints);
        }
