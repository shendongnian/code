     switch(myChoice)
        {
            case RoomType.TwinBB:
                comboBoxroomtype.Text = "TwinBB";
                txtroomrate.Text = "55 USD";
                goto case RoomType.TwinFullboard;
                
    
          case RoomType.TwinFullboard:
                comboBoxroomtype.Text = "TwinFullboard";
                txtroomrate.Text = "65 USD";
                goto case RoomType.DoubleBB;
                
    
            case RoomType.DoubleBB:
                comboBoxroomtype.Text = "DoubleBB";
                txtroomrate.Text = "50 USD";
                goto case RoomType.DoubleFullboard;
                
    
            case RoomType.DoubleFullboard:
                comboBoxroomtype.Text = "DoubleFullboard";
                txtroomrate.Text = "60 USD";
                goto case RoomType.SingleBB;
              
    
            case RoomType.SingleBB:
                comboBoxroomtype.Text = "SingleBB";
                txtroomrate.Text = "40 USD";
                goto case RoomType.SingleFullboard;
               
    
            case RoomType.SingleFullboard:
                comboBoxroomtype.Text = "SingleFullboard";
                txtroomrate.Text = "50 USD";
                break;
            default:
                comboBoxroomtype.Text = "";
                txtroomrate.Text = "";
                break;
        }
