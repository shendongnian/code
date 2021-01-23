    public async Task<IActionResult> Pedigree(int id)
        {
            var dog = await _context.Dogs.SingleOrDefaultAsync(m => m.ID == id);
            var dam = await _context.Dogs.SingleOrDefaultAsync(m => m.Name == dog.Dam);
            var sire = await _context.Dogs.SingleOrDefaultAsync(m => m.Name == dog.Sire);
            var damDam = await _context.Dogs.SingleOrDefaultAsync(m => m.Name == dam.Dam);
            var damSire = await _context.Dogs.SingleOrDefaultAsync(m => m.Name == dam.Sire);
            var sireDam = await _context.Dogs.SingleOrDefaultAsync(m => m.Name == sire.Dam);
            var sireSire = await _context.Dogs.SingleOrDefaultAsync(m => m.Name == sire.Sire);
            Dogs[] dogs = new Dogs[7] { dog, dam, sire, damDam, damSire, sireDam, sireSire };
            return View(dogs.ToList());
        }
