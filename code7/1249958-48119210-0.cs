    //usings
    using Nager.Date;
    using Nager.Date.Extensions;
    //logic
    var date = DateTime.Today; //Set start date
    var countryCode = CountryCode.US; //Set country
    do
    {
        date = date.AddDays(1);
    } while (DateSystem.IsPublicHoliday(date, countryCode) || date.IsWeekend(countryCode));
