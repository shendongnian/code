    new DefaultCase<QuizChoices?, IDialog<string>>((context, value) =>
                    {
                        return Chain.From(() => FormDialog.FromForm(QuizStart.QuizForm, FormOptions.PromptInStart))
                            .Select(c => new QuizParameters
                            {
                                CategoryParameter = c.category.Value.ToString(),
                                DifficultyParameter = c.difficulty.Value.ToString()
                            })
                            .ContinueWith<QuizParameters?, int>(async (ctx, res) =>
                            {
                                await res;
                                
                                IList<QuizQuestion> questions = QuestionsLoader.LoadQuestions(QuizParameters.CategoryParameter, QuizParameters.DifficultyParameter).ToList();
                                return new QuizQuestionsLoader(questions);
                            })
