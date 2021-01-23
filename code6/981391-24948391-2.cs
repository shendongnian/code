    SELECT CableNumber, CblType, ApprxmtLngth, ME.EquipmentNumber as EquipmentNumber1, ME2.EquipmentNumber as EquipmentNumber2, CblStatus, InstallMthd, S.PrdtCd FROM CableId C
     INNER JOIN MajorEquipment ME ON C.FromLoc = ME.MEId
     INNER JOIN MajorEquipment ME2 ON C.ToLoc = ME2.MEId
     INNER JOIN SupplierInfo S ON C.SupplierId = S.SupplierId WHERE
     (@CblType IS NULL OR CblType LIKE @CblType)
     AND (@CblStatus IS NULL OR CblStatus LIKE @CblStatus)
     AND (@FromLoc IS NULL OR ME.EquipmentNumber LIKE @FromLoc)
     AND (@ToLoc IS NULL OR ME2.EquipmentNumber LIKE @ToLoc);
    while (mySqlReader.Read())
    {
        CableID_Controller.CList.Add(new CableID_Model
        {
            CableNumber = Convert.ToString(mySqlReader["CableNumber"]),
            CableType = Convert.ToString(mySqlReader["CblType"]),
            SupplierPart = Convert.ToString(mySqlReader["PrdtCd"]),
            CableLength = Convert.ToInt32(mySqlReader["ApprxmtLngth"]),
            InstallMethod = Convert.ToString(mySqlReader["InstallMthd"]),
            Origin = Convert.ToString(mySqlReader["ME.EquipmentNumber1"]),
            Destination = Convert.ToString(mySqlReader["ME2.EquipmentNumber2"]),
            Status = Convert.ToString(mySqlReader["CblStatus"])
         });
    }
