    private void schedulerControl_AppointmentDrop(object sender, AppointmentDragEventArgs e)
    {
            if (e.EditedAppointment.End < DateTime.Now)
            {
                MessageBox.Show("You can't move appointments to the past");
                e.Handled = true;
                e.Allow = false;
            }
     }
