    // Define this method within your ViewModel class
    public void SetPrintableFlag(IList<Items> items, IList<Pages> pages)
    {
          // Assuming id is a property of your ViewModel class
          switch (id)
          {
                    case 1:
                    case 2:
                        // If there aren't any pages
                        if (!pages.Any())
                        {
                            // Then set your flag to the opposite (you could likely return true here instead)
                            IsPrintableFlag = pages.Any();
                        }
                        break;
                    case 3:
                    default:
                        IsPrintableFlag = false;
          }
    }
