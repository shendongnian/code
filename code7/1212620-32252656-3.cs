    // Change this Int32 to match your @RecordId and @ParentRecordId.  Possibly parameterize this entire code snippet into a method.
    Int32 recordIdToChange = 1;
    Int32 parentRecordIdToChange = 1;
    
    // Set the new primary.
    EmailRecords emailRecordToSetToPrimary = profile.EmailRecords.Where(cs => cs.EmailRecordId == recordIdToChange).FirstOrDefault();
    if (emailRecordToSetToPrimary != null){
       emailRecordToSetToPrimary.IsPrimary = true;
    }
    
    // Only unset those records whose id does not match the new primary AND is currently set as a primary.
    List<EmailRecords> emailRecordsToUnsetFromPrimary = profile.EmailRecords.Where(cs => cs.EmailRecordId != recordIdToChange && cs.IsPrimary == true && cs.ParentRecordId == parentRecordIdToChange).ToList();
    foreach (EmailRecords emailRecordToUnsetFromPrimary in emailRecordsToUnsetFromPrimary){
       emailRecordToUnsetFromPrimary.IsPrimary = false;
    }
    // Perform your save on the emailRecords list collection.
