    try { 
      Bitmap master_bitmap; 
      master_bitmap=BitmapFactory.decodeByteArray(decodedString, 0, ‌​decodedString.‌​leng‌​th); 
      if (master_bitmap != null) { 
        try { 
          ((BitmapDrawable)master_frame.getDrawable()).getBitmap().recycle();
          master_frame.setImageBitmap(master_bitmap); 
        } 
        catch(RuntimeException e) { 
          e.printStackTrace();
        }
      }
    } 
    catch (IllegalArgumentException e) { 
      e.printStackTrace();
    }
