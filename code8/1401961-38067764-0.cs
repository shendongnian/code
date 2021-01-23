    byte[] riff= System.Text.Encoding.ASCII.GetBytes("RIFF");
    bw.Write(riff);
    byte[] fmt = System.Text.Encoding.ASCII.GetBytes("WAVEfmt ");
    bw.Write(fmt);
    byte[] data= System.Text.Encoding.ASCII.GetBytes("data ");
    bw.Write(data);
