    @model IEnumerable<WhenToUseRenderActionAndRenderPartial.Models.Comment>
    <section>
        <header>
            <h3>
                Comments</h3>
        </header>
        @foreach (var comment in Model)
        {
            <article>
                <header>
                    @comment.Author on
                    <time datetime="@comment.DateCreated.ToString("s") ">
                        @comment.DateCreated.ToLongDateString()
                    </time>
                </header>
                <img alt="@comment.Author" src=@comment.ImageUrl />
                <p>
                    @comment.Content
                </p>
            </article>
        }
    </section>
