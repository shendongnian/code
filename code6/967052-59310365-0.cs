foreach (var Control in dataGridView1.Controls)
{
    if (Control.GetType() == typeof(VScrollBar))
    {
        //your checking here
        //specifically... if (((VScrollBar)Control).Visible)
    }
}
