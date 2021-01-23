    var switchValue = IsSelectedOrganizer ? 4 : 0 +
                      IsNewOrganizer ? 2 : 0 +
                      IsOrganizerUserAlreadyExist ? 1 : 0;
    switch (switchValue)
    {
        case 7:
        case 6:
        case 5:
        case 4:
            // IsSelectedOrganizer part
            break;
        case 3:
            // IsNewOrganizer && IsOrganizerUserAlreadyExist part
            break;
        case 2:
            // IsNewOrganizer && !IsOrganizerUserAlreadyExist part
            break;
        default:
            // else part
    }
