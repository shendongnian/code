    public ActionResult CreateMenu(MenuVM model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        // Initialize and save the Menu
        Menu menu = new Menu()
        {
            Name = model.Name,
            AmountPersons = model.AmountPersons
        };
        db.Menus.Add(menu);
        db.SaveChanges(); // you now have the ID of the new menu
        // Save the dishes associated with the menu
        IEnumerable<int> selectedDishes = model.Dishes.Where(x => x.IsSelected).Select(x => x.ID);
        foreach(int id in selectedDishes)
        {
            // You have not indicated the 1-many table the dishes are saved to so adjust as required
            MenuDish dish = new MenuDish()
            {
                MenuId = menu.ID,
                DishId = dish
            };
            db.MenuDishes.Add(dish);
        }
        db.SaveChanges(); // save the selected dishes
        return RedirectToAction(...); // redirect somewhere
    }
