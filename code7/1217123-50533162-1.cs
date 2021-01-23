    using (var saveFileReader = File.OpenText(saveFilePath)) {
        district.isHQ = bool.Parse(saveFileReader.ReadLine());
        district.controllingFaction = StringToFaction(saveFileReader.ReadLine());
        district.agricultureSpecialisation = StringToAgricultureSpecialisation(saveFileReader.ReadLine());
        district.technologySpecialisation = StringToTechnologySpecialisation(saveFileReader.ReadLine());
        district.militarySpecialisation = StringToMilitarySpecialisation(saveFileReader.ReadLine());
    }
