        if (!string.IsNullOrWhiteSpace(quoteQty))
        {
            if (!int.TryParse(quoteQty, out yourmodel.QuoteQuantity))
            {
                // If the TryParse fails and returns false
                // Add a model error. Element ID, then message.
                ModelState.AddModelError("quoteQty",
                                         "Whoops!");
            }
        }
        ...
        // Then do your ModelState.IsValid check and other stuffs
    }
