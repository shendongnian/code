    public void BeginAnimation() {
        Completed += GridLengthAnimation_Completed;
        Target.BeginAnimation(ColumnDefinition.WidthProperty, null);
        Target.BeginAnimation(ColumnDefinition.WidthProperty, this);
    }
    
    private void GridLengthAnimation_Completed(object sender, EventArgs e) {
        //unlocks the property
        Target.BeginAnimation(ColumnDefinition.WidthProperty, null);
    }
