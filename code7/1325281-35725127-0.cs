    public interface IRequest
    {
    }
    public interface IRequestHandler<in TCommand> where TCommand : IRequest
    {
        void HandleCore(TCommand command);
    }
    public class DeleteArticleCommand : IRequest
    {
        public int Id { get; set; }
    }
    public class ArticlesViewModel
    {
        private readonly IRequestHandler<DeleteArticleCommand> _handler;
        public ArticlesViewModel(IRequestHandler<DeleteArticleCommand> handler)
        {
            _handler = handler;
        }
        public void Delete(int articleId)
        {
            _handler.HandleCore(new DeleteArticleCommand { Id = articleId });
        }
    }
    //On client side
    public sealed class WcfServiceCommandHandlerProxy<TCommand> 
        : IRequestHandler<TCommand> where TCommand : IRequest
    {
        public void HandleCore(TCommand command)
        {
            using (var service = new ActuaclWcfServiceClient())
            {
                service.Send(command); //Or however you are working with you WCF client
            }
        }
    }
    //Somewhere on server side
    public class DeleteArticleCommandHandler : IRequestHandler<DeleteArticleCommand>
    {
        private readonly IArticleCrud _articleCrud;
        public DeleteArticleCommandHandler(IArticleCrud articleCrud)
        {
            _articleCrud = articleCrud;
        }
        public void HandleCore(DeleteArticleCommand message)
        {
            articleCrud.Delete(message.Id);
        }
    }
