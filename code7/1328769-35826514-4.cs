    IEnumerable<ReviewViewModel> viewModel = 
        from review in db.reviews
        join comment in db.Comments
        on review.ReviewId equals comment.ReviewId into joinedReviewComment
        select new ReviewViewModel // <-- Always project to a view model
        {
            review.ReviewBody,
            review.ReviewHeadLine,
            Comments = joinedReviewComment.Select(c => new CommentViewModel
            {
                CommentBody = c.CommentBody,
            }).ToList(),
        };
    return View(viewModel.ToList()); // <-- Always pass a view model to your view
