    public IActionResult SendMessage(int id)
    {
        Pet PetData = _context.Pet.Single(m => m.ID == id);
        TempData["PetOwner"] = PetData.CreatedBy;
        TempData["PetName"] = PetData.Name;
        return Redirect("/Messages/Create");
    }
