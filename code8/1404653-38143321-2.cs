        public virtual string SettingsJson { get; set; } // just an auto-implemented property
        ...
        existingEntity.Settings = dto.Settings;
        existingEntity.SettingsJson = JsonConvert.SerializeObject(dto.Settings);
        // save changes
