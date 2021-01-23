          public ReedSolomonEncoder(GenericGF field)
          {
                if (!GenericGF.QR_CODE_FIELD_256.Equals(field))
                {
                  throw new System.ArgumentException("Only QR Code is supported at this time");
                }
