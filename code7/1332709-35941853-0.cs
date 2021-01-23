    public class yourFormState{
     //Assign your properties here        
    }
    private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
         CreateConfigData();
    }
    private void CreateConfigData() {
    using (StreamWriter sw = new StreamWriter("yourConfig.xml")) {
        state.ButtonBackColor = System.Drawing.ColorTranslator.ToHtml(button1.BackColor);
        XmlSerializer ser = new XmlSerializer(typeof(MyFormState));
        ser.Serialize(sw, state);
    }
