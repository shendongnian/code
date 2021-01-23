    TypeTimer enu;
    Enum.TryParse((sender as RadioButton).Tag, out enu);
    Switch(enu)
            {
                case TypeTimer.Unlimited:
                    (code here)
                    break;
    
                case TypeTimer.Countdown:
                         (code here)
                         break;
                case TypeTimer.Limited:
                        (code here)
                        break;
                default:
                        break;
            }
