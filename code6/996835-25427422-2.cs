    private void schedulerControl_AppointmentDrop(object sender, AppointmentDragEventArgs e)
    {
            YourClass temp = e.EditedAppointment.GetRow(schedulerStorage1) as YourClass;
            if(temp.IsStartValid==false)
            {
                MessageBox.Show("Invalid Start");
                e.Handled = true;
               e.Allow = false;
            }
           // if (e.EditedAppointment.End < DateTime.Now)
           // {
           //     MessageBox.Show("You can't move appointments to the past");
           //     e.Handled = true;
           //    e.Allow = false;
           // }
     }
