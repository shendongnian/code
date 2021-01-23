    public partial class Form1 : Form
    {
        private Student StudentRead;
        // rest of your code...
        // from your read method:
        StudentRead = new Student(studentInformationArray); 
        // and finally:
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = StudentRead.GetName();
