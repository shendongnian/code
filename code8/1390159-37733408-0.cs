        return View(new EditUserViewModel()
        {
            Email = user.Email,
            Voornaam = user.Voornaam,
            Achternaam = user.Achternaam,
            Telefoonnummer = user.PhoneNumber
        })
