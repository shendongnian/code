     //Function called when window was load.
     private void window_load(object sender, RoutedEventArgs e)
     {
        studentDataDataSetStudentTableAdapter.ClearBeforeFill = true;
     }
     // Button event called when button press
     private void RefreshDataGrid(object sender, RoutedEventArgs e)
     {
        studentDataDataSetStudentTableAdapter.Fill(studentDataDataSet.Student);
     }
