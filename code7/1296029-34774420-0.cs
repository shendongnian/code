        private void button1_Click(object sender, EventArgs e)
        {
            try {
                string[] slist = text.Split(':');
                foreach (string mobno in slist) {
                    SmsSubmitPdu pdu;
                    byte dcs = (byte)DataCodingScheme.GeneralCoding.Alpha7BitDefault;
                    pdu = new SmsSubmitPdu(textmsg.Text,mobno,dcs);
                    int times = 1;
                    comm.SendMessage(pdu);
                }
                MessageBox.Show("Message sent sucessfully");
            } catch (Exception ex) {
                MessageBox.Show("Modem not avaliable");
            }
        }
