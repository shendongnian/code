    @model List<SectionVM>
    @foreach(var section in Model)
    {
        <h2>@section.Title</h2>
        foreach(var subSection in section.SubSections)
        {
            <h3>@subSection.Title</h3>
            foreach(var question in subSection.Questions)
            {
                <p>@question.QuestionText</p>
                ....
            }
        }
    }
