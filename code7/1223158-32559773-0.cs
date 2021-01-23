      String phone = item.PrimaryPhoneNumber.ToString();
    
      mainStr = String.Format("({0})-{1}-{2}",
        phone.SubString(0, 3), // starting from 0th, 3 characters length
        phone.SubString(3, 3), // starting from 3d, 3 characters length
        phone.SubString(6));   // starting from 6th, up to the end
