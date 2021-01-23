    private void TypePicker_SelectionChanged( object sender, SelectionChangedEventArgs e ) {
        IsDirty = true;
        FirstDependentTextBox.Text = ViewModelObject.Property1;
        SecondDependentTextBox.Text = ViewModelObject.Property2;
        MyCommands.SaveChanges.CanExecute( this, OkButton );
        e.Handled = true;
    }
