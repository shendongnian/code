        // POST: ListItems/QuickCreate
        // Create item without showing view, return to home 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> QuickCreate(ListItem listItem)
        {
                _context.ListItem.Add(listItem);
                await _context.SaveChangesAsync();
                return Redirect("/"); 
        }
