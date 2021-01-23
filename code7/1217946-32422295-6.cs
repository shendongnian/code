        // actor
        if (rb_Actor.Checked)
        {
            if (e.X <= 150)
            {
                var actor = new Actor(name, e.X, e.Y);
                _actors.Add(actor);
                pl_Diagram.Invalidate();  // trigger the paint event
                //DrawElements();
            }
        }
        // use case
        if (rb_Use_Cases.Checked)
        {
            var useCase = new UseCase(name, e.X, e.Y);
            _useCases.Add(useCase);
            pl_Diagram.Invalidate();  // trigger the paint event
            //DrawElements();
        }
