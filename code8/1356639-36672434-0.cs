    // POST: Users/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id) {
        var user = await _userManager.FindByIdAsync(id.ToString());
        var result = await _userManager.DeleteAsync(user);
        return RedirectToAction("Index");
    }
