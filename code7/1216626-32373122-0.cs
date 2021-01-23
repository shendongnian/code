    if (flag)
    {
      serialPort1.WriteLine("SetVolt 8V On\r");
      serialPort1.ReadLine();
      serialPort1.ReadLine();
      btn8V_Off.Visible = true;
      btn8V_On.Visible = false;
      btn12V_Off.Visible = false;
      btn12V_On.Visible = true;
      flag= false;
    }
    else
    {
      serialPort1.Write("GetVolt 8V\r");
      serialPort1.ReadLine();
      tb12V_8V_V.Text = serialPort1.ReadLine();
      serialPort1.Write("GetVolt 5V3\r");
      serialPort1.ReadLine();
      tb5V3_V.Text = serialPort1.ReadLine();
      serialPort1.Write("GetVolt 3V5\r");
      serialPort1.ReadLine();
      tb3V5_3V3_V.Text = serialPort1.ReadLine();
    }
