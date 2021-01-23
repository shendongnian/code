    // 3 possible inputs:
    long input = 0x00012F0000071F;
    long input2 = 3143;
    string inputS = "0x00012F0000071F";
    // take binary input as such
    byte out1 = (byte)((input >> 4) & 0xFFFFFF );
    byte out2 = (byte)(input >> 36);
    // take string as decimals
    byte out3 = Convert.ToByte(inputS.Substring(5, 2));
    byte out4 = Convert.ToByte(inputS.Substring(13, 2));
    // take binary as decimal
    byte out5 = (byte)(10 * ((input >> 40) & 0xF) + (byte)((input >> 36) & 0xF));
    byte out6 = (byte)(10 * ((input >> 8) & 0xF) + (byte)((input >> 4) & 0xF));
    // take integer and pick out 3rd and last byte 
    byte out7 = (byte)(input2 >> 8);
    byte out8 = (byte)(input2 & 0xFF);
    // combine two bytes to one integer
    int byte1and2 = (byte)(12) << 8 | (byte)(71) ;
    Console.WriteLine(out1.ToString());
    Console.WriteLine(out2.ToString());
    Console.WriteLine(out3.ToString());
    Console.WriteLine(out4.ToString());
    Console.WriteLine(out5.ToString());
    Console.WriteLine(out6.ToString());
    Console.WriteLine(out7.ToString());
    Console.WriteLine(out8.ToString());    
    Console.WriteLine(byte2.ToString());
