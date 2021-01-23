    if ( currentCheckBox.IsChecked == true && nonCurrentCheckBox.IsChecked == false )
    {
    	criteria.Add( new Predicate<CompanyModel>( x => x.CurrentStatus == 1 ) );
    }
    else if ( nonCurrentCheckBox.IsChecked == true && currentCheckBox.IsChecked == false )
    {
    	criteria.Add( new Predicate<CompanyModel>( x => x.CurrentStatus == 0 ) );
    }
    else if ( nonCurrentCheckBox.IsChecked == true && currentCheckBox.IsChecked == true )
    {
    	criteria.Add( new Predicate<CompanyModel>( x => ( x.CurrentStatus == 0 || x.CurrentStatus == 1 ) ) );
    }
