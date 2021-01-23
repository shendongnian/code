        var AcctLst = gd.validateGroupMembershipUploadDetails(_input);
        Mapper.CreateMap<Data.Entities.Upload.ChapterCodeValidationOutput, Business.Upload.ChapterCodeValidationOutput>();
        Mapper.CreateMap<Data.Entities.Upload.GroupCodeValidationOutput, Business.Upload.GroupCodeValidationOutput>();
        Mapper.CreateMap<Data.Entities.Upload.GroupMembershipValidationOutput, Business.Upload.GroupMembershipValidationOutput>();
        var result = Mapper.Map<Data.Entities.Upload.GroupMembershipValidationOutput, Business.Upload.GroupMembershipValidationOutput>(AcctLst);
        return result;
